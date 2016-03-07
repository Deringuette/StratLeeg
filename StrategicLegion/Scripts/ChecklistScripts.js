function addChecklistGroup() {
    var newGroupName = document.getElementById('NewGroupTextbox').value

    var Checklist = document.getElementById("NewChecklistDiv");

    var newGroupsDiv = document.createElement('div');
    newGroupsDiv.setAttribute('class','checklistGroupDiv')

    var newHeaderDiv = document.createElement('div');
    newHeaderDiv.setAttribute('class', 'checklistHeaderDiv')

    var newHeaderLabel = document.createElement('label');
    newHeaderLabel.setAttribute('class', 'checklistHeaderLabel')
    newHeaderLabel.innerHTML = newGroupName;

    Checklist.appendChild(newGroupsDiv);
    newGroupsDiv.appendChild(newHeaderDiv);
    newHeaderDiv.appendChild(newHeaderLabel);

    //var newItemPartialDiv = document.createElement('div');
    //newItemPartialDiv.innerHTML = HTML.renderPartial("_ChecklistItem", Model)
    //newGroupsDiv.appendChild(newItemPartialDiv);
}

function addChecklistItem(parentDiv, elementName) {
    var innerDiv = document.createElement('div');
    var elementLabel = document.createElement('label');
    elementLabel.innerHTML = elementName;
    innerDiv.appendChild(elementLabel);
    document.getElementById(parentDiv).appendChild(innerDiv);
}