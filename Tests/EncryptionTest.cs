using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

namespace Tests;

public class EncryptionTest {

    [Test]
    public void SmallPacketTest() {
        byte[] key = new byte[16];
        byte[] iv = new byte[16];
        new Random().NextBytes(key);
        new Random().NextBytes(iv);
        
        MemoryStream s = new();
        
        // using Aes aes = Aes.Create();
        // aes.FeedbackSize = 8;
        // aes.Mode = CipherMode.CFB;
        // aes.Padding = PaddingMode.None;
        // ICryptoTransform encryptor = aes.CreateEncryptor();

        CfbBlockCipher cfb = new(new AesEngine(), 8);
        BufferedBlockCipher cipher = new(cfb);
        cipher.Init(true, new ParametersWithIV(new KeyParameter(key), iv));

        CipherStream cipherStream = new(s, null, cipher);
        
        // using CryptoStream cryptoStream = new(s, encryptor, CryptoStreamMode.Write, leaveOpen: true);

        byte[] packet = [78, 2]; // small packet data (e.g., 2 bytes)
        cipherStream.Write(packet, 0, packet.Length);
        // cipherStream.Flush();
        
        byte[] encryptedData = s.ToArray();
        
        // fails
        Assert.That(encryptedData.Length, Is.GreaterThan(0), "Encrypted data should not be empty");
    }
}