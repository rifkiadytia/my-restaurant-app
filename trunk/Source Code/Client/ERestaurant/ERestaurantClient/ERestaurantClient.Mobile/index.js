
$(function() {
    var navigationType = ERestaurantClient.config.navigationType,
        startupView = "Login";

    // Uncomment the line below to disable platform-specific look and feel and to use the Generic theme for all devices
    // DevExpress.devices.current({ platform: "generic" });

    if(DevExpress.devices.real().platform === "win8" && DevExpress.devices.real().deviceType === "phone") {
        document.addEventListener("deviceready", onDeviceReady, false);
    }

    function onDeviceReady() {
        document.addEventListener("backbutton", onBackKeyDown, false);
        ERestaurantClient.app.navigatingBack.add(function() {
            if(!ERestaurantClient.app.canBack() && window.external) {
                window.external.Notify("DevExpress.ExitApp");
            }
        });
    }

    function onBackKeyDown() {
        DevExpress.hardwareBackButton.fire();
    }

    ERestaurantClient.app = new DevExpress.framework.html.HtmlApplication({
        namespace: ERestaurantClient,
        navigationType: navigationType,
        navigation: ERestaurantClient.config.navigation
    });

    $(window).unload(function() {
        ERestaurantClient.app.saveState();
    });

    ERestaurantClient.app.router.register(":view/:id", { view: startupView, id: undefined });
    ERestaurantClient.app.navigate();
});
