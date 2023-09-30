




/*****
 * 
 * 
 * 
 *   Different Project "Medical Appointment" 
 * 
 * 
 * ****/



var medicalAppointment = new MedicalAppointment("Hussain Ghazaly", new DateTime(2023, 4, 3));

// overwrite month and day
medicalAppointment.OverwriteMonthAndDay(5, 1);

//add a given number of months and days
medicalAppointment.MoveByMonthsAndDays(1, 2);


var nameOnly = new MedicalAppointment("Name Only");

Console.ReadKey();










/*
 * 
 * Create Class & Constructors for MedicalAppointment project
 * 
 **/


class MedicalAppointment
{
    private string _patientName;
    private DateTime _date;

    // ctor + TAB + TAB
    public MedicalAppointment(string patientName, DateTime date)
    {
        _patientName = patientName;
        _date = date;
    }


    class MedicalAppointmentPrinter
    {
        public void Print(MedicalAppointment medicalAppointment)
        {
            Console.WriteLine("Appointment will be take place on " + medicalAppointment.GetDate);
        }
    }

    public DateTime GetDate() => _date;

    //this : keyword used to call one another  structor in the class 
    //public MedicalAppointment(string patientName) : this(patientName, 7) 
    //{
    //    //_patientName = patientName;
    //    //_date= DateTime.Now.AddDays(7); //  Now: get the current date & time 
    //}


    //public MedicalAppointment(string patientName)
    //{
    //    _patientName = patientName; // the  datre field will be defult value 
    // will not be used first , cuz it has missing value 
    //}

    public MedicalAppointment(string patientName, int daysFromNow = 7)
    {
        _patientName = patientName;
        _date = DateTime.Now.AddDays(daysFromNow);
    }

    public void Reschedule(DateTime date)
    {
        _date = date;
        var printer = new MedicalAppointmentPrinter();
        printer.Print(this); // this refer to the current instance of the medical appointment class
                             // so when this line will be executed , it will call the 
    }

    // Method OverLoading is having multiple methods with the same name ,
    // we need to separate between the methods weather with (count of the parameters - their type - the order) 
    public void OverwriteMonthAndDay(int month, int day)
    {
        _date = new DateTime(_date.Year, month, day);
    }

    public void MoveByMonthsAndDays(int monthToAdd, int daysToAdd)
    {
        _date = new DateTime(_date.Year, _date.Month + monthToAdd, _date.Day + daysToAdd);
    }
}
