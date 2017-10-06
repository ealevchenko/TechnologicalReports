$(document).ready(function () {

    $('#table-average-daily-expenses').DataTable({
        "paging": false,
        "info": false
    });

    myVar = $.cookie('lang');

    $('#select-range').dateRangePicker(
    {
        startOfWeek: 'monday',
        //separator: ' to ',
        language: myVar,
        format: myVar == 'en' ? 'MM/DD/YYYY' : 'DD.MM.YYYY',
        autoClose: true,
        singleDate: true,
        showShortcuts: false,
        getValue: function () {
            if ($('#date').val())
                return $('#date').val();
            else
                return '';
        },
        setValue: function (s, s1) {
            $('#date').val(s1);

        },
    }).bind('datepicker-closed', function () {
        $('form#fmList').submit(); // Отправить форму
    });

    // Нажата кнопка назад
    $('#button-previous').click(

        function () {
            var date = $('input#date').val();
            var dateArray = (myVar == 'en' ? date.split('/') : date.split('.'));
            var Day = (myVar == 'en' ? dateArray[1] : dateArray[0])
            var Month = (myVar == 'en' ? dateArray[0] : dateArray[1])
            var Year = dateArray[2];
            var D = new Date(Year, Month, Day);
            D.setDate(D.getDate() - 1);
            var d = D.getDate();
            var sd = d.toString();
            if (d < 10) { sd = "0" + sd; }
            var m = D.getMonth();
            var sm = m.toString();
            if (m < 10) { var sm = "0" + sm; }
            var y = D.getFullYear();
            var datenow = (myVar == 'en' ? sm + '/' + sd + '/' + D.getFullYear() : sd + '.' + sm + '.' + D.getFullYear())
            $('input#date').val(datenow);
            $('form#fmList').submit(); // Отправить форму
        });
    // Нажата кнопка вперед
    $('#button-next').click(

        function () {
            var date = $('input#date').val();
            var dateArray = (myVar == 'en' ? date.split('/') : date.split('.'));
            var Day = (myVar == 'en' ? dateArray[1] : dateArray[0])
            var Month = (myVar == 'en' ? dateArray[0] : dateArray[1])
            var Year = dateArray[2];
            var D = new Date(Year, Month, Day);
            D.setDate(D.getDate() + 1);
            var d = D.getDate();
            var sd = d.toString();
            if (d < 10) { sd = "0" + sd; }
            var m = D.getMonth();
            var sm = m.toString();
            if (m < 10) { var sm = "0" + sm; }
            var y = D.getFullYear();
            var datenow = (myVar == 'en' ? sm + '/' + sd + '/' + D.getFullYear() : sd + '.' + sm + '.' + D.getFullYear())
            $('input#date').val(datenow);
            $('form#fmList').submit(); // Отправить форму
        });

    //валидация
    $(function () {

        $('form#fmList').validate({
            highlight: function (element, errorClass) {
                $(element).add($(element).parent()).addClass("invalidElem");
            },
            unhighlight: function (element, errorClass) {
                $(element).add($(element).parent()).removeClass("invalidElem");
            },
            errorElement: "label",
            errorClass: "errorMsg"
        });

        $.validator.addMethod("mydate", function (value, element) {
            return /^[0-9]{1,2}[\/\.][0-9]{1,2}[\/\.][0-9]{4}$/i.test(value);
        }, myVar == 'en' ? "Enter the correct date (mm/dd/yyyy)" : "Введите правильно дату (дд.мм.гггг)")

        $.validator.addClassRules({
            dateValidation: {
                mydate: true,
                required: true
            }
        })

        $('input#date').addClass("dateValidation").change(function (e) {
            $('form#fmList').validate().element($(e.target));
        });
    });
});

function selectPeriod(data) {

    LockScreenOff();
    var target = $("#content");
    target.empty();
    target.append(data);
    $('#table-average-daily-expenses').DataTable({
        "paging": false,
        "info": false
    });
}

function OnBegin() {
    LockScreen('Мы обрабатываем ваш запрос...');
}

function OnFailure(request, error) {
    //alert("This is the OnFailure Callback:" + error);
}

function OnComplete(request, status) {
    //alert("This is the OnComplete Callback: " + status);        
}


