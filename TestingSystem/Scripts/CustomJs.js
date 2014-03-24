window.onload = function () {
    setDeleteMarksToFalse();
};

function setDeleteMarksToFalse() {
    var x = document.getElementById("answers").rows;
    for (var i = 0; i < x.length; i++) {
        $("#Answers_"+i+"__deleteThis").attr("value", "False");
    }
}

function removeNestedForm(element, container, deleteElement) {
    $container = $(element).parents(container);
    $container.find(deleteElement).val('True');
    $container.hide();
}

function addNestedForm(container, counter, ticks, content) {
    var nextIndex = $(counter).length;
    var pattern = new RegExp(ticks, "gi");
    content = content.replace(pattern, nextIndex);
    $(container).append(content);
}