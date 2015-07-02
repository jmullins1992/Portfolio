$(document).ready(function() {
    $(".btnViewClasses").click(function() {
        ViewCoursesForStudent($(this).closest("li"));
    });

    $(".btnViewGrades").click(function() {
        LoadGradesAndShowModal($(this));
    });
});

function ViewCoursesForStudent(jqListItem) {
    jqListItem.find(".studentCourses").fadeToggle();
}

function LoadGradesAndShowModal(jqButtonPressed) {
    var courseId = jqButtonPressed.attr("data-courseId");
    var studentId = jqButtonPressed.attr("data-studentId");

    $.get(apiPath, { courseId: courseId, studentId: studentId })
        .done(function (data) {
    $("#myModalBody").html(data);

    $("#myModal").modal("show");
    });
}