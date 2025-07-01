using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Minecraft.Implementations.Client.Tools;

// TODO, WIP
public class MicrosoftAuthenticator {
    // ID's and tokens
    private const string ClientId = "c36a9fb6-4f2a-41ff-90bd-ae7cc92031eb";  // prism launcher's client ID :)
    
    // URLs
    private const string DeviceCodeUrl = $"https://login.microsoftonline.com/consumers/oauth2/v2.0/devicecode?client_id={ClientId}&scope=XboxLive.SignIn%20XboxLive.offline_access";
    private const string CodeAuthUrl = "https://login.live.com/oauth20_remoteconnect.srf?otc=";  // ends in the otc (usercode) that the user has to enter
    private const string TokenPollUrl = $"https://login.microsoftonline.com/consumers/oauth2/v2.0/token";
    private const string XBoxLiveAuthUrl = "https://user.auth.xboxlive.com/user/authenticate";
    private const string XstsAuthUrl = "https://xsts.auth.xboxlive.com/xsts/authorize";
    private const string MinecraftAuthUrl = "https://api.minecraftservices.com/authentication/login_with_xbox";
    private const string MinecraftProfileUrl = "https://api.minecraftservices.com/minecraft/profile";
    
    public async Task<MinecraftProfile> Authenticate(Action<string> consumeAuthUrl) {
        HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync(DeviceCodeUrl);
        if (!response.IsSuccessStatusCode) {
            throw new Exception($"Failed to obtain device code: {response.StatusCode} - {response.ReasonPhrase}");
        }
        
        string responseBody = await response.Content.ReadAsStringAsync();
        JObject json = JObject.Parse(responseBody);

        string deviceCode = json["device_code"]!.ToObject<string>()!;

        string userCode = json["user_code"]!.ToObject<string>()!;
        consumeAuthUrl(CodeAuthUrl + userCode);
        
        // poll for the token
        string accessToken;
        while (true) {
            await Task.Delay(1000);  // wait 1 second before polling again
            
            HttpResponseMessage pollResponse = await client.PostAsync(TokenPollUrl, new FormUrlEncodedContent(new Dictionary<string, string> {
                { "grant_type", "urn:ietf:params:oauth:grant-type:device_code" },
                { "client_id", ClientId },
                { "device_code", deviceCode }
            }));
            
            string pollResponseBody = await pollResponse.Content.ReadAsStringAsync();
            JObject poll = JObject.Parse(pollResponseBody);
        
            if (poll.TryGetValue("error", out JToken? error)) {
                string errorCode = error.ToObject<string>()!;
        
                switch (errorCode) {
                    case "authorization_pending":
                        Console.Write(".");
                        continue;  // just wait
                    
                    case "authorization_declined":
                        // User declined the authorization
                        throw new Exception("Authorization declined");
                    
                    case "bad_verification_code":
                        throw new Exception("Device code was invalid");
                    
                    case "expired_token":
                        throw new Exception("Device code expired, please try again");
                }
                Console.WriteLine("Polling for token failed: " + error.ToObject<string>());
                continue;
            }
            Console.WriteLine();
            
            // no error
            accessToken = poll["access_token"]!.ToObject<string>()!;
            break;
        }
        
        // Now we have the access token, we can use it to authenticate with Xbox Live
        Console.WriteLine("Access token obtained: " + accessToken);

        string xblToken;
        string xblUserHash;
        {  // Xbox Live authentication
            dynamic xboxAuthData = new {
                Properties = new {
                    AuthMethod = "RPS",
                    SiteName = "user.auth.xboxlive.com",
                    RpsTicket = "d=" + accessToken // the access token is prefixed with "d="
                },
                RelyingParty = "http://auth.xboxlive.com",
                TokenType = "JWT"
            };

            HttpResponseMessage xboxResponse = await client.PostAsync(XBoxLiveAuthUrl,
                new StringContent(JsonConvert.SerializeObject(xboxAuthData), Encoding.UTF8, "application/json"));

            string xboxResponseBody = await xboxResponse.Content.ReadAsStringAsync();
            JObject xbox = JObject.Parse(xboxResponseBody);

            xblToken = xbox["Token"]!.ToObject<string>()!;
            xblUserHash = xbox["DisplayClaims"]!["xui"]![0]!["uhs"]!.ToObject<string>()!;
        }

        string xstsToken;
        {  // XSTS Auth
            dynamic xstsData = new {
                Properties = new {
                    SandboxId = "RETAIL",
                    UserTokens = new[] { xblToken }
                },
                RelyingParty = "rp://api.minecraftservices.com/",
                TokenType = "JWT"
            };
            HttpResponseMessage xstsResponse =
                await client.PostAsync(XstsAuthUrl, 
                    new StringContent(JsonConvert.SerializeObject(xstsData), Encoding.UTF8, "application/json"));
            string xstsResponseBody = await xstsResponse.Content.ReadAsStringAsync();
            
            JObject xsts = JObject.Parse(xstsResponseBody);

            if (!xstsResponse.IsSuccessStatusCode) {
                uint errorCode = xsts["XErr"]!.ToObject<uint>();

                throw errorCode switch {
                    2148916227 => new Exception("User is banned from Xbox Live"),
                    2148916233 => new Exception("User does not have an Xbox Live account"),
                    2148916235 => new Exception("XBox Live is not available in user's region"),
                    2148916237 or 2148916236 => new Exception("User needs adult verification to use Xbox Live"),
                    2148916238 => new Exception("User is child and needs parental consent to use Xbox Live"),
                    _ => new Exception("Unknown error during XSTS authentication: " + errorCode)
                };
            }
            
            xstsToken = xsts["Token"]!.ToObject<string>()!;
        }

        string minecraftAccessToken;
        {  // Minecraft Auth
            dynamic minecraftAuthData = new {
                identityToken = $"XBL3.0 x={xblUserHash};{xstsToken}"
            };
            HttpResponseMessage minecraftResponse = await client.PostAsync(MinecraftAuthUrl,
                new StringContent(JsonConvert.SerializeObject(minecraftAuthData), Encoding.UTF8, "application/json"));
            
            string minecraftResponseBody = await minecraftResponse.Content.ReadAsStringAsync();
            JObject minecraft = JObject.Parse(minecraftResponseBody);
            
            minecraftAccessToken = minecraft["access_token"]!.ToObject<string>()!;
        }

        {
            HttpRequestMessage request = new(HttpMethod.Get, MinecraftProfileUrl);
            request.Headers.Add("Authorization", $"Bearer {minecraftAccessToken}");
            HttpResponseMessage profileResponse = await client.SendAsync(request);
            if (!profileResponse.IsSuccessStatusCode) {
                throw new Exception($"Failed to get Minecraft profile: {profileResponse.StatusCode} - {await profileResponse.Content.ReadAsStringAsync()}");
            }
            
            string profileResponseBody = await profileResponse.Content.ReadAsStringAsync();
            JObject profile = JObject.Parse(profileResponseBody);
            string username = profile["name"]!.ToObject<string>()!;
            string uuid = profile["id"]!.ToObject<string>()!;
            
            return new MinecraftProfile(minecraftAccessToken, username, uuid);
        }
    }

    public record MinecraftProfile(string AccessToken, string Username, string Uuid);
}
