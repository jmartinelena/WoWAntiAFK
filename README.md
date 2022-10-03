# WoWAntiAFK
An **attempt** at keeping you from disconnecting from the game World of Warcraft Classic for being AFK once you are already logged in.

It works by disconnecting your character, waiting for 1.5 minutes and reconnecting you again every time a random amount of time between 5 to 20 minutes passes. This *should* only work in Windows.

Download it [here](https://drive.google.com/file/d/17wAHrCPp0skp07aVrxrCzbVKJdvlezOI/view?usp=sharing).

## Instructions

<ins><b>Do NOT run this while in queue</b>. It will click the character migration button if you do. <b>Only</b> run this with your character already logged in.</ins>

<ol>
    <li><b>Have your character logged in and ready to go afk</b>. You need your chat's message box (where you type in your messages) to be <b>clear</b>.</li>
    <li>Open the console app.</li>
    <li>Pray that you don't get randomly disconnected from the server.</li>
    <li>Once you are ready to play again, simply close the console. You can also close the game and the console will eventually stop running.</li>
</ol>

This will fail if:
<ul>
    <li>Your game crashes.</li>
    <li>You get randomly disconnected.</li>
    <li>It takes longer than a minute for your character to disconnect and reconnect again.</li>
    <li>You alt tab out of the game during the logout->wait->login process.</li>
</ul>

## To do
<ol>
    <li>Let you choose how much time to wait in between every cycle.</li>
    <li>Let you choose how much time to wait in between loading screens (disconnecting and reconnecting).</li>
    <li>Make this work on linux/mac. <-- I think using .NET instead of .NET Framework would do the trick</li>
    <li>Make this less sketchy lol. <small><-- This won't happen</small></li>
</ol>
