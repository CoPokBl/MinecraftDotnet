# TODO

- use Identifiers instead of strings for protocol stuffs
- fix head look randomly snapping
- better world handling
- Use more efficient lock for world cached chunks
- Add packet building to send buffering

- cubic chunks
- fix proxy no sound bug (deserialise issue?)
- make GitHub project for it
- time each event callback and make warning if over value (have some way of benchmarking tick time usage, perhaps have an option to record the data to be analysed, or just use dottrace idk)
- make client library that can be used for a full client or bot impl
- make all public fields properties ( with get and set), especially in packets, and make packets readonly
