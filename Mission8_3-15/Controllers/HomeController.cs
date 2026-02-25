using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission8_3_15.Models;
using System.Diagnostics;
using Task = System.Threading.Tasks.Task;

namespace Mission8_3_15.Controllers;

public class HomeController : Controller
{
    // Set up repository pattern
    private iTasksRepository _repo;
    public HomeController(iTasksRepository temp)
    {
        _repo = temp;
    }

    // Get route for the home page, which will display all incomplete tasks
    [HttpGet]
    public IActionResult Index()
    {
        // Get all tasks that are not completed
        var tasks = _repo.Tasks
                .Where(x => x.Completed == false)
                .ToList();

        // Pass the list of tasks to the view
        return View(tasks);
    }

    // Get route for the page to add a task
    [HttpGet]
    public IActionResult Task()
    {
        ViewBag.Categories = _repo.Categories.ToList();

        return View("Task", new TaskItem());
    }

    // Post route for submitting a task to the database
    [HttpPost]
    public IActionResult Task(Task t)
    {
        // Validate task before submission
        if (ModelState.IsValid)
        {
            _repo.SaveTask(t);
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View("Task", t);
        }
    }

    // Get route for editing a task
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _repo.Tasks.Single(x => x.TaskId == id);
        ViewBag.Categories = _repo.Categories.ToList();

        return View("Task", task);
    }

    // Post route for submitting an edited task to the database
    [HttpPost]
    public IActionResult Edit(TaskItem updatedTask)
    {
        if (ModelState.IsValid)
        {
            _repo.UpdateTask(updatedTask);
            return RedirectToAction("Index");
        }

        ViewBag.Categories = _repo.Categories.ToList();
        return View("Task", updatedTask);
    }

    // Get route for confirming deletion of a task
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var task = _repo.Tasks.Single(x => x.TaskId == id);
        return View(task);
    }

    // Post route for deleting a task from the database
    [HttpPost]
    public IActionResult Delete(TaskItem task)
    {
        _repo.DeleteTask(task);
        return RedirectToAction("Index");
    }

    // Post route for marking a task as completed
    [HttpPost]
    public IActionResult MarkCompleted(int id)
    {
        var task = _repo.Tasks.Single(x => x.TaskId == id);
        task.Completed = true; // Mark as Completed 
        _repo.UpdateTask(task);

        return RedirectToAction("Index");
    }

}