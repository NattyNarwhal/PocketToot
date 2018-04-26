# PocketToot

A Mastodon API client (tested with Mastodon v2.3.3; untested with Pleroma but
likely to work) for Pocket PCs 5.0 or newer. (It could work with 2003, but the
TLS library situation is too bad for me to justify targetting it.)

Speaking of TLS, your server needs to present a TLS protocol version compatible
with your Windows CE version. Windows Mobile 5.0 supports TLSv1.0, but probably
not SNI. 6.x should be much better in this regard.

In debug builds, certificate name validation will be disabled, which helps
connecting when the certificate store is out of date, but no SNI means you have
no virtual hosts, effectively. Keep this in mind. If your instance admin is
unwilling to change settings for the sake of this (I wouldn't blame them) then
you have other options like a proxy or setting up your own instance.

If you're crazy as me, feel free to submit a PR/file issues!

## Building

Requires Visual Studio 2008 with Smart Devices support, and
`Newtonsoft.Json.Compact`, the last version of which was 3.5.

Build the solution and correct paths to things, if needed. That's it.