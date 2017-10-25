//Прибавить дату
function AddDay(date) {
    var dateArray = (myVar == 'en' ? date.split('/') : date.split('.'));
    var Day = (myVar == 'en' ? dateArray[1] : dateArray[0])
    var Month = (myVar == 'en' ? dateArray[0] : dateArray[1])
    var Year = dateArray[2];
    var D = new Date(Year, Month-1, Day);
    D.setDate(D.getDate() + 1);
    var d = D.getDate();
    var sd = d.toString();
    if (d < 10) { sd = "0" + sd; }
    var m = D.getMonth()+1;
    var sm = m.toString();
    if (m < 10) { var sm = "0" + sm; }
    var y = D.getFullYear();
    return (myVar == 'en' ? sm + '/' + sd + '/' + D.getFullYear() : sd + '.' + sm + '.' + D.getFullYear())
}
//отнять дату
function SubDay(date) {
        var dateArray = (myVar == 'en' ? date.split('/') : date.split('.'));
        var Day = (myVar == 'en' ? dateArray[1] : dateArray[0])
        var Month = (myVar == 'en' ? dateArray[0] : dateArray[1])
        var Year = dateArray[2];
        var D = new Date(Year, Month-1, Day);
        D.setDate(D.getDate() - 1);
        var d = D.getDate();
        var sd = d.toString();
        if (d < 10) { sd = "0" + sd; }
        var m = D.getMonth()+1;
        var sm = m.toString();
        if (m < 10) { var sm = "0" + sm; }
        var y = D.getFullYear();
        return (myVar == 'en' ? sm + '/' + sd + '/' + D.getFullYear() : sd + '.' + sm + '.' + D.getFullYear())
}