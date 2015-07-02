var canSubmitGrade = true;

$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
    $(".gradeAssignmentCell").click(function () {
        ActivateEditCellMode($(this));
    });

    //$(".gradeAssignmentCell button").click(function (e) {
    //    e.stopPropagation();
    //    UpdateGradedAssignment($(this).closest("td"));

    //});
    $(".gradeAssignmentCell form").on('submit', function (e) {
        e.preventDefault();
        UpdateGradedAssignment($(this).closest("td"));
        
    });

    $(".gradeAssignmentCell input").blur(function (e) {
        e.stopPropagation();
        UpdateGradedAssignment($(this).closest("td"));
        
    });
});

function ActivateEditCellMode(jqCellClicked) {
    if (jqCellClicked.find('.notEditingCell').is(':visible')) {
        jqCellClicked.find(".notEditingCell").toggle();
        jqCellClicked.find(".editCell").toggle();
        jqCellClicked.find("input").focus().select();
    }
}

function UpdateGradedAssignment(jqCellClicked) {
    if (!canSubmitGrade) {
        return;
    }
    canSubmitGrade = false;

    jqCellClicked.children(".notEditingCell").show();
    jqCellClicked.children(".editCell").hide();


    var pointsEarned = jqCellClicked.find("#ra_PointsEarned").val();
    pointsEarned = Math.round(pointsEarned * 100) / 100;
    var pointsPossible = jqCellClicked.find("#ra_PossiblePoints").val();
    var rosterAssignmentId = jqCellClicked.find("#ra_RosterAssignmentId").val();
    var rosterId = jqCellClicked.find("#ra_RosterId").val();

    $.getJSON(window.apiPath, {
        rosterId: rosterId,
        rosterAssignmentId: rosterAssignmentId,
        pointsEarned: pointsEarned,
        possiblePoints: pointsPossible
    }).done(function (response) {
        canSubmitGrade = true;
        if (response.Success) {
            $('#response-error p').html(" ");
            if (response.Percentage) {
                jqCellClicked.find(".notEditingCell").html(response.Percentage + '%');
            } else {
                jqCellClicked.find(".notEditingCell").html('');
            }
            jqCellClicked.parent().find(".overallGradeCell").html(response.OverallGrade);
        }
        else {
            $('#response-error p').html(response.Message);

        }
    });
}