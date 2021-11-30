
var generateCandidacies = function (e) {
    e.preventDefault();

    var form = $(this);
    var url = form.prop("action");
    var count = $("#count").val();
    var capacity = $("#capacity").val();

    if (count) {

        $.ajax({
            url: url,
            method: "POST",
            data: {
                count: count,
                capacity: capacity
            }
        }).done(function (result) {

            $("#preferencies-content").html(result);
            $(".sortable").sortable();
        });
    }
}

$(document).ready(function () {

    // Evénements
    $(document).on("submit", "#choose-count", generateCandidacies);
});