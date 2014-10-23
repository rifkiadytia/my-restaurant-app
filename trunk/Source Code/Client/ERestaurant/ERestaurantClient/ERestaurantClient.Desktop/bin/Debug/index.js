
$(function() {
    var navigationType = ERestaurantClient.config.navigationType,
        startupView = "About";

    DevExpress.devices.current("desktop");

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
