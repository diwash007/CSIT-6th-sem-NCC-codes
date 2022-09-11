using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller {

    DataContext dc = new DataContext();

    //read
    public IActionResult Index() {
        return View(dc.students);
    }

    //create
    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student s) {
        dc.students.Add(s);
        dc.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    //delete
    [HttpPost]
    public IActionResult Delete(int id) {
        var student = dc.students.Find(id);
        if (student == null) return RedirectToAction(nameof(Index));
        dc.students.Remove(student);
        dc.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    //update
    public IActionResult Update() {
        return View();
    }

    [HttpPost]
    public IActionResult Update(Student s) {
        var student = dc.students.Find(s.studentId);
        if (student == null) return RedirectToAction(nameof(Index));
        student.Class = s.Class;
        student.Name = s.Name;
        student.RollNo = s.RollNo;
        dc.students.Update(student);
        dc.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}