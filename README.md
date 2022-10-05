# WoWAntiAFK
An **attempt** at keeping you from disconnecting from the game World of Warcraft Classic for being AFK once you are already logged in.

It works by disconnecting your character, waiting for 1.5 minutes and reconnecting you again every time a random amount of time between 5 to 20 minutes passes. This *should* only work in Windows.  

The program is multi-account friendly, that means you can have multiple characters logged in and **every one** of those would be kept from logging out, as long as every WoW client is running under the process "WowClassic.exe". If you don't care about this feature, just run one WoW client and you'll be golden.

Download the installer from the latest release [here](https://github.com/jmartinelena/WoWAntiAFK/releases).

## Instructions

<ins><b>Do NOT run this while in queue</b>. It will click the character migration button if you do. <b>Only</b> run this with your character already logged in.</ins>

<ol>
    <li><b>Have your character(s) logged in and ready to go afk</b>. You need your chat's message box (where you type in your messages) to be <b>clear</b>.</li>
    <li>Open the console app.</li>
    <li>Pray that you don't get randomly disconnected from the server.</li>
    <li>Once you are ready to play again, simply close the console. You can also close the game and the console will eventually stop running.</li>
</ol>

Do note that the program *DOES NOT* actually check if you are logged in or not, so be careful and check up on it to see if it's working properly every now and then. If you've gotten randomly disconnected from the server on any account, you should restart the program (make sure to have your characters ready to afk again).

This will fail if:
<ul>
    <li>Your game crashes.</li>
    <li>You get randomly disconnected.</li>
    <li>It takes longer than a minute for your character to disconnect and reconnect again.</li>
    <li>You alt tab out of the game during the logout->wait->login process.</li>
    <li>Some addon interferes with typing in your chat after you've logged in.</li>
</ul>

Any incidents (in-game/account penalties, wipes, clicking wrong stuff, etc.) are **your** responsibility. Check up on the program every now and then.

## To do
<ul>
    <li>Let you choose how much time to wait in between every cycle.</li>
    <li>Let you choose how much time to wait in between loading screens (disconnecting and reconnecting).</li>
    <li>Make this work on linux/mac. <-- I think using .NET instead of .NET Framework would do the trick</li>
    <li>Make this less sketchy lol. <small><-- This won't happen</small></li>
    <li>Add an optional prompt to exclude a certain process id from disconnecting (allows you to play on your main). <-- Any deaths/wipes caused by this would be on you</li>
</ul>
