


$(document).ready(function () {

    $(".datepicker").datepicker({
        dateFormat: "dd-mm-yy",
        changeMonth: true,
        changeYear: true

    });

    var $StartDate, $EndDate;
    var $ToolId = $('#ToolId').val();

    $('#ToolId').on('change', function () {
        $ToolId = $(this).val();
        console.log('selected item: ', $ToolId);

    });

    $('#StartDate').on('change', function () {
        $StartDate = $(this).val();
        console.log('selected item: ', $StartDate);

    });
    $('#EndDate').on('change', function () {
        $EndDate = $(this).val();
        console.log('selected item: ', 'change')
        if ($StartDate != null && $EndDate > $StartDate) {
            $.post("/Reservations/CalculatePrice", {
                ToolId: $ToolId, StartDate: $StartDate, EndDate: $EndDate
            })
                .done(function (data) {
                    console.log(data);
                    $('#Price').val(data);
                });
        }

    });


});