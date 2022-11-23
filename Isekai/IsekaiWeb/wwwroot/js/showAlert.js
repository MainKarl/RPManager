function showAlert(name) {
    $.alert({
        title: 'Armor Added!',
        content: name + ' was added to the armor list!',
        confirm: function () {
            refreshArmorList(1)
        }
    })
}