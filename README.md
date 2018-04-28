# PocketToot

![Federated timeline](https://i.imgur.com/yvZ3Hqe.png) ![Status view](https://i.imgur.com/jDEmxv7.png)

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

Smartphone SDK is possible, but needs a new UI for certain, probably library
rework to handle the subset of a subset that is a Smartphone Compact Framework.
Sorry Q/Blackjack owners.

If you're crazy as me, feel free to submit a PR/file issues!

## Building

Requires Visual Studio 2008 with Smart Devices support, and
`Newtonsoft.Json.Compact`, the last version of which was 3.5.

Build the solution and correct paths to things, if needed. That's it.

## Usage

To install, just sync the CAB file over and install. You will need .NET Compact
Framework version 3.5; the latest version of which I provide for Windows Mobile
2005 devices [here](https://cmpct.info/%7Ecalvin/PocketToot/KB970549/NETCFv35.wm.armv4i.cab).
(Exception messages for .NET can be found [here](https://cmpct.info/%7Ecalvin/PocketToot/Diagnostics)).

You need to acquire a development key; the application doesn't currently
support fetching OAuth keys. From Mastodon's web UI, go to settings, then
development, then create new application. Call it PocketToot, then once saved,
put "Your access token" into the token field of the settings when launching the
app, and your instance's domain name in hostname. You can hit "test" to ensure
that both the token is valid and you can connect to the server with your
device's TLS capabilities.

Once launched, the UI should be fairly self-explanatory. While I try to polish
it, there are rough edges and uninmplemented features.

Timelines are manually refreshed.