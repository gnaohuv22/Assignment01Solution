using AutoMapper;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;

namespace eStoreClient.Controllers
{
    public class MemberController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly string _baseUrl = "https://localhost:7194/api/MemberAPI";

        public MemberController(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        //GET: Member
        public async Task<IActionResult> Index()
        {
            var members = await _httpClient.GetFromJsonAsync<IEnumerable<Member>>($"{_baseUrl}/GetAllMembers");
            var memberDtos = _mapper.Map<IEnumerable<MemberDto>>(members);
            return View(memberDtos);
        }

        //GET: Member/Details/{id} 
        public async Task<IActionResult> Details(int id)
        {
            var member = await _httpClient.GetFromJsonAsync<Member>($"{_baseUrl}/GetMemberById/{id}");
            if (member == null)
            {
                return NotFound();
            }
            var memberDto = _mapper.Map<MemberDto>(member);
            return View(memberDto);
        }

        //GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Member/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberDto memberDto)
        {
            if (!ModelState.IsValid)
            {
                return View(memberDto);
            }

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/AddMember", memberDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating new member.");
            return View(memberDto);
        }

        //GET: Member/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var member = await _httpClient.GetFromJsonAsync<Member>($"{_baseUrl}/GetMemberById/{id}");
            if (member == null)
            {
                return NotFound();
            }

            var memberDto = _mapper.Map<MemberDto>(member);
            return View(memberDto);
        }

        //POST: Member/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MemberDto memberDto)
        {
            if (!ModelState.IsValid || id != memberDto.MemberId)
            {
                return BadRequest();
            }

            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/UpdateMember/{id}", memberDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while updating the member.");
            return View(memberDto);
        }

        //GET: Member/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var member = await _httpClient.GetFromJsonAsync<Member>($"{_baseUrl}/GetMemberById/{id}");
                if (member == null)
                {
                    return NotFound();
                }
                return View(member);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while fetching the member.");
                return RedirectToAction(nameof(Index));
            }
        }

        //POST: Member/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, IFormCollection collection)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/DeleteMember/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "An error occurred while deleting the member.");
                var member = await _httpClient.GetFromJsonAsync<Member>($"{_baseUrl}/GetMemberById/{id}");
                return View(member);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the member.");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
