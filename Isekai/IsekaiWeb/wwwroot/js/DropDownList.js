
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