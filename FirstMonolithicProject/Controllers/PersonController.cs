
using FirstMonolithicProject.ApplicationServices.Dtos.PersonDtos;
using FirstMonolithicProject.ApplicationServices.Services.Contracts;
using FirstMonolithicProject.Models;
using FirstMonolithicProject.Models.DomainModels.PersonAggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PersonController : Controller
{

    private readonly IPersonApplicationService _personApplicationService;

    #region [-ctor-]
    public PersonController(IPersonApplicationService personApplicationService)
    {
        _personApplicationService = personApplicationService;

    }
    #endregion

    #region [- Detail() -]

    public async Task<IActionResult> Detail(GetPersonDtoById getPersonDtoById)
    {
        var person = await _personApplicationService.GetById(getPersonDtoById);
        if (person == null)
        {
            return NotFound();
        }
        var getPersonDto = new GetPersonDto()
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Age = person.Age,
        };
        return View(getPersonDto);
    }
    #endregion

    #region [- Edit() -]
    #region [- Get() -]
    [HttpGet]
    public async Task<IActionResult> Edit(GetPersonDtoById getPersonDtoById)
    {
        var person=await _personApplicationService.GetById(getPersonDtoById);
        if (person==null)
        {
            return NotFound();
        }
        var editDto = new PutPersonDto()
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Age = person.Age,
        };
        return View(editDto);
    }
    #endregion
    #region [- Post() -]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(PutPersonDto putPersonDto)
    {
        if (ModelState.IsValid)
        {
            await _personApplicationService.Put(putPersonDto);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(putPersonDto);
        }
    }
    #endregion
    #endregion

    #region [- Delete() -]
    #region [- Get() -]
    public async Task<IActionResult> Delete(GetPersonDtoById getPersonDtoById) 
    {
        if (getPersonDtoById == null )
        {
            return NotFound();
        }

        var person = await _personApplicationService.GetById(getPersonDtoById);

        if (person == null)
        {
            return NotFound();
        }
        return View(person);
    }

    #endregion
    #region [- Post() -]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeletePersonDto deletePersonDto)
    {
        if (ModelState.IsValid)
        {
            await _personApplicationService.Delete(deletePersonDto);
            return RedirectToAction(nameof(Index));

        }
        else
        {
            return View(deletePersonDto);
        }
    }
    #endregion
    #endregion

    #region [- Index() -]
    public async Task<IActionResult> Index()
    {
        var result = await _personApplicationService.GetAllPerson();
        return View(result);
    }
    #endregion

    #region [- create() -]

    #region [- Get() -]
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    #endregion
    #region [- Post() -]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> create(PostPersonDto postPersonDto)

    {
        if (ModelState.IsValid)
        {
            await _personApplicationService.Post(postPersonDto);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(postPersonDto);
        }

    }
    #endregion

    #endregion

    
}