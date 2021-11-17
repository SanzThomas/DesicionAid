
var generateCandidacies = function (e) {
    e.preventDefault();

    var form = $(this);
    var url = form.prop("action");
    var counter = $("#count").val();

    if (counter) {

        $.ajax({
            url: url,
            method: "POST",
            data: {
                count: counter
            }
        }).done(function (result) {

            $("#preferencies-content").html(result);
            $(".sortable").sortable();
        });
    }
}

var generateResults = function (e) {
    e.preventDefault();

    var link = $(this);
    var url = link.prop("href");

    var allStudents = $(".students-items.sortable");
    var allEstablishments = $(".establishments-items.sortable");

    var data = {
        students: [allStudents.length],
        establishments: [allEstablishments.length]
    };

    allStudents.each(function (i, item) {

        var id = $(item).prev("h5").data("id");
        var name = $(item).prev("h5").html();

        var preferencyOrders = $(item).children();
        var preferencies = [preferencyOrders.length];

        preferencyOrders.each(function (j, preferency) {

            var preferencyId = $(preferency).data("id");
            var preferencyName = $(preferency).html();

            preferencies[j] = { id: preferencyId, name: preferencyName };
        });

        data.students[i] = { id, name, preferencies };
    });

    allEstablishments.each(function (i, item) {

        var id = $(item).prev("h5").data("id");
        var name = $(item).prev("h5").html();

        var preferencyOrders = $(item).children();
        var preferencies = [preferencyOrders.length];

        preferencyOrders.each(function (j, preferency) {

            var preferencyId = $(preferency).data("id");
            var preferencyName = $(preferency).html();

            preferencies[j] = { id: preferencyId, name: preferencyName };
        });

        data.establishments[i] = { id, name, preferencies };
    });

    $.ajax({
        url: url,
        method: "POST",
        data: data
    }).done(function (result) {
        
    });
}


$(document).ready(function () {

    // Evénements
    $(document).on("submit", "#choose-count", generateCandidacies);
    $(document).on("click", "#validate-preferencies", generateResults);
});