function refreshPassiveList(search, type, page) {
    $('#passive-list').html("");
    $.ajax({
        url: '/Passive/Refresh',
        data: {
            pageNumber: page,
            search: search,
            passiveType: type
        },
        success: function (data) {
            $('#passive-list').html(data);
        }
    })
}

function refreshArmorList(page) {
    $('#armor-list').html("");
    $.ajax({
        url: '/Armor/Refresh',
        data: {
            pageNumber: page
        },
        success: function (data) {
            $('#armor-list').html(data);
        }
    })
}
function refreshArmorAdd() {
    $('#armor-add').html("");
    $.ajax({
        url: '/Armor/Add',
        success: function (data) {
            $('#armor-add').html(data);
        }
    })
}
function ArmorAddPost() {
    var name = document.getElementById('Name').value;
    $.ajax({
        url: '/Armor/Add',
        type: 'POST',
        data: {
            name: document.getElementById('Name').value,
            power: document.getElementById('Power').value,
            passive: document.getElementById('Passive').value
        },
        success: function (data) {
            if (data == true) {
                $.alert({
                    title: 'Armor Added!',
                    content: name + ' was added to the Armor list!',
                    buttons: {
                        confirm: function () {
                            refreshArmorList(1);
                        }
                    }
                });
            }
        }
    })
}
function ArmorDeletePost(valueId, name) {
    $.ajax({
        url: '/Armor/Delete',
        type: 'POST',
        data: {
            id: valueId
        },
        success: function (data) {
            console.log("data:"+data);
            if (data == true) {
                $.alert({
                    title: 'Armor Deleted!',
                    content: name + ' was deleted from the Armor list!',
                    buttons: {
                        confirm: function () {
                            refreshArmorList(1);
                        }
                    }
                });
            }
        }
    })
}