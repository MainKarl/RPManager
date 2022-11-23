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
    $.ajax({
        url: '/Armor/Add',
        type: 'POST',
        data: {
            name: document.getElementById('Name').value,
            power: document.getElementById('Power').value,
            passive: document.getElementById('Passive').value
        },
        success: function (data) {
            showAlert(data);
        }
    })
}