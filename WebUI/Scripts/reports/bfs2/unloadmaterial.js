$(document).ready(function () {

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
            var datenow = SubDay(date);
            $('input#date').val(datenow);
            $('form#fmList').submit(); // Отправить форму
        });
    // Нажата кнопка вперед
    $('#button-next').click(

        function () {
            var date = $('input#date').val();
            var datenow = AddDay(date);
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


