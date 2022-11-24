function showAlertCreated(type, name) {
    $.alert({
        title: type + ' Added!',
        content: name + ' was added to the ' + type + ' list!',
        confirm: function (data) {
            if (data != ' ') {
                switch (name) {
                    case 'Armor':
                        refreshArmorList(1);
                        break;

                    default:
                        break;
                }
            }
        }
    })
}

function showAlertDeleted(type, name) {
    $.alert({
        title: type + ' Deleted!',
        content: name + ' was deleted from the ' + type + ' list!',
        confirm: function () {
            switch (name) {
                case 'Armor':
                    refreshArmorList(1);
                    break;

                default:
                    break;
            }
        }
    })
}