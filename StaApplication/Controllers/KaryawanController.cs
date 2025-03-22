using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaApplication.Data;
using StaApplication.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StaApplication.Controllers
{
    public class KaryawanController : Controller
    {
        private readonly StaApplicationContext _context;

        public KaryawanController(StaApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Karyawan.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDKaryawan,NmKaryawan,TglMasukKerja,Usia")] Karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karyawan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(karyawan);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karyawan = await _context.Karyawan.FindAsync(id);
            if (karyawan == null)
            {
                return NotFound();
            }
            return View(karyawan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDKaryawan,NmKaryawan,TglMasukKerja,Usia")] Karyawan karyawan)
        {
            if (id != karyawan.IDKaryawan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karyawan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KaryawanExists(karyawan.IDKaryawan))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(karyawan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var karyawan = await _context.Karyawan.FindAsync(id);
            if (karyawan != null)
            {
                _context.Karyawan.Remove(karyawan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KaryawanExists(string id)
        {
            return _context.Karyawan.Any(e => e.IDKaryawan == id);
        }
    }
}
