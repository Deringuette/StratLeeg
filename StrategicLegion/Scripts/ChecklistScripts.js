function addChecklistGroup(checklistGroupNumber) {
    //Find parent div of checklist
    var Checklist = $('NewChecklistDiv');

    //Create div for the new group
    var newGroupDiv = document.createElement('div');
    newGroupDiv.setAttribute('class', 'checklistGroupDiv')
    newGroupDiv.setAttribute('id', 'ChecklistGroupDiv' + checklistGroupNumber)


    //Create Div and label to hold header of new group
    var newHeaderDiv = document.createElement('div');
    newHeaderDiv.setAttribute('class', 'checklistHeaderDiv')

    var newHeaderLabel = document.createElement('label');
    newHeaderLabel.setAttribute('class', 'checklistHeaderLabel')
    newHeaderLabel.setAttribute('id', 'ChecklistHeaderLabel' + checklistGroupNumber)

    var headerTextbox = document.getElementById('NewGroupTextbox');
    var newGroupName = headerTextbox.value;
    newHeaderLabel.innerHTML = newGroupName;

    //Add the group div to the checklist and add the header to the new group
    Checklist.appendChild(newGroupDiv);
    newGroupDiv.appendChild(newHeaderDiv);
    newHeaderDiv.appendChild(newHeaderLabel);

    //Add Delete header button beside label
    var deleteHeaderButton = document.createElement('input');
    deleteHeaderButton.setAttribute('type', 'button');
    deleteHeaderButton.setAttribute('id', 'DeleteHeaderButton' + checklistGroupNumber);
    deleteHeaderButton.setAttribute('value', 'x');
    deleteHeaderButton.setAttribute('class', 'removeHeaderButton');
    deleteHeaderButton.setAttribute('onclick', 'removeChecklistHeader(\'' + checklistGroupNumber + '\')');
    newHeaderDiv.appendChild(deleteHeaderButton);


    //Create Div which will later hold checklist items for the group
    var groupItemsDiv = document.createElement('div');
    groupItemsDiv.setAttribute('class', 'checklistItemsDiv')
    groupItemsDiv.setAttribute('id', 'ChecklistItemsDiv' + checklistGroupNumber)
    newGroupDiv.appendChild(groupItemsDiv);
    
    //Create Div which will hold the item textbox and add button
    var newItemTextButtonDiv = document.createElement('div');
    newItemTextButtonDiv.setAttribute('class', 'newItemTextButtonDiv');
    newItemTextButtonDiv.setAttribute('id', 'NewItemTextButtonDiv' + checklistGroupNumber);
    newGroupDiv.appendChild(newItemTextButtonDiv);

    //Create the 'New Group Name Textbox' button
    var newItemText = document.createElement('input');
    newItemText.setAttribute('type','text');
    newItemText.setAttribute('id', 'NewItemTextbox' + checklistGroupNumber);
    newItemText.setAttribute('class', 'newItemTextbox');
    newItemText.setAttribute('placeholder','Item Name');

    //Create the 'Add New Group' button
    var newItemButton = document.createElement('input');
    newItemButton.setAttribute('type', 'button');
    newItemButton.setAttribute('id', 'NewItemAddButton' + checklistGroupNumber);
    newItemButton.setAttribute('value', '+');
    newItemButton.setAttribute('class', 'newItemAddButton');
    newItemButton.setAttribute('onclick', 'addChecklistItem(\'' + checklistGroupNumber + '\')');

    //Add the New Group Name Textbox and Button to appropriate div
    newItemTextButtonDiv.appendChild(newItemText);
    newItemTextButtonDiv.appendChild(newItemButton);

    //Clear header name textbox for next input
    headerTextbox.value = '';
}

function addChecklistItem(groupNumber) {
    //Get name of new checklist item and node of appropriate group
    var itemNameTextbox = document.getElementById('NewItemTextbox' + groupNumber);
    var newItemName = itemNameTextbox.value;

    //Find div we will add to
    var groupItemsdiv = document.getElementById('ChecklistItemsDiv' + groupNumber);

    //Create item div and label
    var itemDiv = document.createElement('div');
    itemDiv.setAttribute('class', 'checklistItemDiv');
    var itemLabel = document.createElement('label');
    itemLabel.setAttribute('class', 'checklistItemLabel');
    itemLabel.innerHTML = newItemName;

    //Add div and label to form
    groupItemsdiv.appendChild(itemDiv);
    itemDiv.appendChild(itemLabel);

    //Clear item name textbox for next input
    itemNameTextbox.value = '';
}

function removeChecklistHeader(groupNumber) {
    var groupDiv = document.getElementById('ChecklistGroupDiv' + groupNumber);
    groupDiv.empty();
    //for (var child in groupDiv.childNodes)
     //   child.remove();
    groupDiv.setAttribute('class', 'hidden');
    groupDiv.setAttribute('id', '');
    
}