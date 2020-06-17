$(function () {
    $("#addnewProjectButton").click(function (e) {
        e.preventDefault();
        $("#addnewProjectDiv").toggle();
    });
    $("#addnewExpirenceButton").click(function (e) {
        e.preventDefault();
        $("#addnewExpirenceDiv").toggle();
    });

    $("#OrganizationSelect").change(function () {
        var value = $(this).children("option:selected").val();
        if (value == 0) {
            $("#OrganizationNameDiv").toggle();
        } else {
            $("#OrganizationNameDiv").css('display', 'none');

        }

    });
    $("#FrameworkSelect").change(function () {
        var value = $(this).children("option:selected").val();
        if (value == 0) {
            $("#FrameworkNameDiv").toggle();
        } else {
            $("#FrameworkNameDiv").css('display', 'none');
        }
    });
    $("#DomainSelect").change(function () {
        var value = $(this).children("option:selected").val();
        if (value == 0) {
            $("#DomainNameDiv").toggle();
        } else {
            $("#DomainNameDiv").css('display', 'none');
        }
    });

});
