function twitchLive(elementId, channelName) {
    new Twitch.Embed(elementId, {
        //width: 854,
        //height: 480,
        channel: channelName,
        // Only needed if this page is going to be embedded on other websites
        //parent: ["embed.example.com", "othersite.example.com"]
    });
}
