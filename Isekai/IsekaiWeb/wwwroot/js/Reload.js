function refreshPassiveList(page) {
    $('#passive-list').html("");
    $.ajax({
        url: '/Passive/Refresh',
        data: {
            pageNumber: page,
            search: document.getElementById('Search').value,
            passiveType: document.getElementById('Category').value
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
function refreshArmorUpdate(id, name, power, passive) {
    var elementId = "#" + id;
    $(elementId).html();
    $.ajax({
        url: '/Armor/Update',
        data: {
            id: id,
            name: name,
            power: power,
            passive: passive
        },
        success: function (data) {
            $(elementId).html(data);
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
            path: document.getElementById('Path').value,
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
function ArmorUpdatePost() {
    var id = document.getElementById('Update-Id').value;
    var nameString = 'Name-' + id;
    var powerString = 'Power-' + id;
    var passiveString = 'Passive-' + id;
    var name = document.getElementById(nameString).value;
    $.ajax({
        url: '/Armor/PostUpdate',
        type: 'POST',
        data: {
            id: id,
            name: name,
            power: document.getElementById(powerString).value,
            passive: document.getElementById(passiveString).value
        },
        success: function (data) {
            if (data == true) {
                $.alert({
                    title: 'Armor Updated!',
                    content: name + ' was updated!',
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

function refreshWeaponAdd() {
    $('#weapon-add').html("");
    $.ajax({
        url: '/Weapon/Add',
        success: function (data) {
            $('#weapon-add').html(data);
        }
    })
}
function WeaponAddPost() {
    var error = false;
    var weaponName = document.getElementById('Name');
    var weaponPrice = document.getElementById('Price');
    var rankElement = document.getElementById('Rank').childNodes[1].childNodes[1];
    var damageTypeElement = document.getElementById('DamageType').childNodes[1].childNodes[1];
    var weaponTypeElement = document.getElementById('WeaponType').childNodes[1].childNodes[1];

    if (weaponName.value == "") {
        document.getElementById('name-error').innerHTML = "The name is required!";
        error = true;
    }
    else { document.getElementById('name-error').innerHTML = ""; }

    if (rankElement.nodeValue.startsWith("--")) {
        document.getElementById('rank-error').innerHTML = "You must choose a rank!";
        error = true;
    }
    else { document.getElementById('rank-error').innerHTML = ""; }

    if (damageTypeElement.nodeValue.startsWith("--")) {
        document.getElementById('damageType-error').innerHTML = "You must choose a damage type!";
        error = true;
    }
    else { document.getElementById('damageType-error').innerHTML = ""; }

    if (weaponTypeElement.nodeValue.startsWith("--")) {
        document.getElementById('weaponType-error').innerHTML = "You must choose a weapon type!";
        error = true;
    }
    else { document.getElementById('weaponType-error').innerHTML = ""; }

    if (weaponPrice.value == '') {
        document.getElementById('price-error').innerHTML = "The price is required!";
        error = true;
    }
    else { document.getElementById('price-error').innerHTML = ""; }

    if (!error) {
        $.ajax({
            url: '/Weapon/Add',
            type: 'POST',
            data: {
                name: weaponName.value,
                damage: document.getElementById('Damage').value,
                accuracy: document.getElementById('Accuracy').value,
                crit: document.getElementById('Crit').value,
                price: document.getElementById('Price').value,
                rank: rankElement.nodeValue.slice(1),
                damageType: damageTypeElement.nodeValue.slice(1),
                type: weaponTypeElement.nodeValue.slice(1),
                path: document.getElementById('Path').value,
                passive: document.getElementById('Passive').value
            },
            success: function (data) {
                if (data == true) {
                    $.alert({
                        title: 'Weapon Added!',
                        content: name + ' was added to the Weapon list!',
                        buttons: {
                            confirm: function () {
                                //document.getElementById('button-add').classList.remove('hidden');
                                //document.getElementById('weapon-form').classList.add('hidden');
                                //$('#weapon-form').html("");
                                //refreshWeaponList(1);
                            }
                        }
                    })
                }
            }
        })
    }
}
function refreshWeaponUpdate() {

}
function WeaponUpdatePost() {

}
function WeaponDeletePost() {

}
function refreshWeaponList(page) {
    $('#weapon-list').html("");
    $.ajax({
        url: '/Weapon/Refresh',
        data: {
            pageNumber: page,
            weaponType: document.getElementById('SelectedWeaponType').value
        },
        success: function (data) {
            $('#weapon-list').html(data);
        }
    })
}