var currentUserID;
function OnHyperLinkClick(ID) {
    currentUserID = ID;
    //detailGrid.PerformCallback();
}
function OnDetailGridBeginCallback(s, e) {
    e.customArgs['ID'] = currentUserID;
}
function OnDetailGridEndCallback(s, e) {
    if (!popup.IsVisible())
        popup.Show();
}


