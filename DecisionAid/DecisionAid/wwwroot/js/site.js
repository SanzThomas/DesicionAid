
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

//var generateResults = function (e) {
//    e.preventDefault();

//    var link = $(this);
//    var url = link.prop("href");

//    var allStudents = $(".students-items.sortable");
//    var allEstablishments = $(".establishments-items.sortable");

//    var data = {
//        students: [allStudents.length],
//        establishments: [allEstablishments.length]
//    };

//    allStudents.each(function (i, item) {

//        var id = $(item).prev("h5").data("id");
//        var name = $(item).prev("h5").html();

//        var preferencyOrders = $(item).children();
//        var preferencies = [preferencyOrders.length];

//        preferencyOrders.each(function (j, preferency) {

//            var preferencyId = $(preferency).data("id");
//            var preferencyName = $(preferency).html();

//            preferencies[j] = { id: preferencyId, name: preferencyName };
//        });

//        data.students[i] = { id, name, preferencies };
//    });

//    allEstablishments.each(function (i, item) {

//        var id = $(item).prev("h5").data("id");
//        var name = $(item).prev("h5").html();

//        var preferencyOrders = $(item).children();
//        var preferencies = [preferencyOrders.length];

//        preferencyOrders.each(function (j, preferency) {

//            var preferencyId = $(preferency).data("id");
//            var preferencyName = $(preferency).html();

//            preferencies[j] = { id: preferencyId, name: preferencyName };
//        });

//        data.establishments[i] = { id, name, preferencies };
//    });

//    $.ajax({
//        url: url,
//        method: "POST",
//        data: {
//            student: data.students[i],
//            establishment: data.establishments[i]
//        }
//    });

//    for (var i = 0; i < data.length; i++) {

//        $.ajax({
//            url: url,
//            method: "POST",
//            data: {
//                student: data.students[i],
//                establishment: data.establishments[i]
//            }
//        });
//    }

//}

//var generateResults = function (e) {
//    e.preventDefault();

//    var allStudents = $(".students-items.sortable");
//    var allEstablishments = $(".establishments-items.sortable");

//    allStudents.each(function (i, item) {

//        var id = $(item).prev("h5").data("id");
//        var name = $(item).prev("h5").html();

//        var input = $("<input>");
//        input.prop("name", "students[" + i + "].Id");
//        input.prop("for", "students[" + i + "].Id");
//        input.prop("id", "students[" + i + "].Id");
//        input.addClass("d-none");
//        input.val(id);
//        $(item).prev("h5").append(input);

//        input = $("<input>");
//        input.prop("name", "students[" + i + "].Name");
//        input.prop("for", "students[" + i + "].Name");
//        input.prop("id", "students[" + i + "].Name");
//        input.addClass("d-none");
//        input.val(name);
//        $(item).prev("h5").append(input);

//        var preferencyOrders = $(item).children();

//        preferencyOrders.each(function (j, preferency) {

//            var preferencyId = $(preferency).data("id");
//            var preferencyName = $(preferency).html();

//            var input = $("<input>");
//            input.prop("name", "students[" + i + "].Preferencies[" + j + "].Id");
//            input.prop("for", "students[" + i + "].Preferencies[" + j + "].Id");
//            input.prop("id", "students[" + i + "].Preferencies[" + j + "].Id");
//            input.addClass("d-none");
//            input.val(preferencyId);
//            $(preferency).append(input);

//            input = $("<input>");
//            input.prop("name", "students[" + i + "].Preferencies[" + j + "].Name");
//            input.prop("for", "students[" + i + "].Preferencies[" + j + "].Name");
//            input.prop("id", "students[" + i + "].Preferencies[" + j + "].Name");
//            input.addClass("d-none");
//            input.val(preferencyName);
//            $(preferency).append(input);
//        });
//    });

//    allEstablishments.each(function (i, item) {

//        var id = $(item).prev("h5").data("id");
//        var name = $(item).prev("h5").html();

//        var input = $("<input>");
//        input.prop("name", "establishments[" + i + "].Id");
//        input.prop("for", "establishments[" + i + "].Id");
//        input.prop("id", "establishments[" + i + "].Id");
//        input.addClass("d-none");
//        input.val(id);
//        $(item).prev("h5").append(input);

//        input = $("<input>");
//        input.prop("name", "establishments[" + i + "].Name");
//        input.prop("for", "establishments[" + i + "].Name");
//        input.prop("id", "establishments[" + i + "].Name");
//        input.addClass("d-none");
//        input.val(name);
//        $(item).prev("h5").append(input);

//        var preferencyOrders = $(item).children();

//        preferencyOrders.each(function (j, preferency) {

//            var preferencyId = $(preferency).data("id");
//            var preferencyName = $(preferency).html();

//            var input = $("<input>");
//            input.prop("name", "establishments[" + i + "].Preferencies[" + j + "].Id");
//            input.prop("for", "establishments[" + i + "].Preferencies[" + j + "].Id");
//            input.prop("id", "establishments[" + i + "].Preferencies[" + j + "].Id");
//            input.addClass("d-none");
//            input.val(preferencyId);
//            $(preferency).append(input);

//            input = $("<input>");
//            input.prop("name", "establishments[" + i + "].Preferencies[" + j + "].Name");
//            input.prop("for", "establishments[" + i + "].Preferencies[" + j + "].Name");
//            input.prop("id", "establishments[" + i + "].Preferencies[" + j + "].Name");
//            input.addClass("d-none");
//            input.val(preferencyName);
//            $(preferency).append(input);
//        });
//    });

//    $("#generate-solution").submit();
//}

$(document).ready(function () {

    // Evénements
    $(document).on("submit", "#choose-count", generateCandidacies);
    //$(document).on("click", "#validate-preferencies", generateResults);
});