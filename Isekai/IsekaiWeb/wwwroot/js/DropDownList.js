
const clickList = (event) => {
    toggleList(event.target.id);
}
const chooseItem = (event) => {
    var itemChoose = event.path[0].innerText.slice(1);
    var itemChooseUpper = event.path[0].innerText.slice(1).toUpperCase();
    var parent = event.path[3];
    var parentText = parent.childNodes[1].innerText.slice(1).toUpperCase();

    var docParent = document.getElementById(parent.id);
    if (docParent.classList.value.includes('selected-')) {
        docParent.classList.remove('selected-' + parentText);
        document.getElementById(parentText).classList.remove('sitem-' + parentText);
        document.getElementById(parentText).classList.add('item-' + parentText);

        docParent.classList.add('selected-' + itemChooseUpper);
        document.getElementById(event.path[1].id).classList.remove('item-' + itemChooseUpper);
        document.getElementById(event.path[1].id).classList.add('sitem-' + itemChooseUpper);
    }
    else {
        docParent.classList.add('selected-' + itemChooseUpper);
        document.getElementById(event.path[1].id).classList.remove('item-' + itemChooseUpper);
        document.getElementById(event.path[1].id).classList.add('sitem-' + itemChooseUpper);
    }

    var newText = '<span class="icon"></span> ' + itemChoose;
    event.path[3].childNodes[1].innerHTML = newText;

    hideList(parent.id);

    event.stopPropagation();
    event.preventDefault();
}
const choosePassive = (event) => {
    var itemChoose = event.path[0].innerText.slice(1);
    var parent = event.path[3];

    addPassive(itemChoose);
    hideList(parent.id);

    event.stopPropagation();
    event.preventDefault();
}

function toggleList(id) {
    var element = document.getElementById(id);
    if (element.classList.contains('active')) {
        element.classList.remove('active');
    }
    else {
        element.classList.add('active');
    }
}
function showList(id) {
    var element = document.getElementById(id);
    element.classList.add('active');
}
function hideList(id) {
    var element = document.getElementById(id);
    element.classList.remove('active');
}
function addChildEvent(id) {
    var parent = document.getElementById(id);
    var childs = parent.childNodes[3].childNodes;
    var list = Array.from(childs);
    list.forEach(function (item) {
        if (item.nodeName != '#text') {
            item.addEventListener('click', chooseItem);
        }
    });
}

function addPassive(choosePassive) {
    var passiveList = document.getElementById(document.querySelector('[id^="Passive-List"]').id);
    var passive = document.getElementById(document.querySelector('[id^="Passive"]').id);
    var idPassive = choosePassive.replace(/\s/g, '');
    var newPassive = "<div id='" + idPassive + "' class='passive-single mb-2 col-12 col-sm-12 col-md-5 col-lg-5 col-xl-5'>" + choosePassive + "</div>";

    if (passive.value == '') {
        passive.value = choosePassive;
        passiveList.insertAdjacentHTML("afterbegin", newPassive);
        document.getElementById(idPassive).addEventListener('click', function () {
            removePassive(choosePassive);
        });
    }
    else {
        if (verifyPassive(passive, choosePassive) == "TRUE") {
            passive.value += ";" + choosePassive;
            passiveList.insertAdjacentHTML("afterbegin", newPassive);
            document.getElementById(idPassive).addEventListener('click', function () {
                removePassive(choosePassive);
            });
        }
    }
}
function removePassive(choosePassive) {
    var rPassive = document.getElementById(choosePassive.replace(/\s/g, ''));
    var passive = document.getElementById(document.querySelector('[id^="Passive"]').id);
    var list = passive.value.split(';');

    if (passive.value != '') {
        if (verifyPassive(passive, choosePassive == "TRUE")) {
            var newPassive = "";
            for (var i = 0; i < list.length; i++) {
                if (list[i] != choosePassive) {
                    if (newPassive == "") {
                        newPassive += list[i];
                    }
                    else {
                        newPassive += ";" + list[i];
                    }
                }
            }

            passive.value = newPassive;
            rPassive.remove();
        }
    }
}
function verifyPassive(passives, nPassive) {
    var list = passives.value.split(';');
    for (let i = 0; i < list.length; i++) {
        if (nPassive == list[i]) {
            return "FALSE";
        }
    }
    return "TRUE";
}

function addPassiveEvent(id) {
    var parent = document.getElementById(id);
    var childs = parent.childNodes[3].childNodes;
    var list = Array.from(childs);
    list.forEach(function (item) {
        if (item.nodeName != '#text') {
            item.addEventListener('click', choosePassive);
        }
    });
}