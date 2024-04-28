﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppRestSeam.Models;
using Microsoft.EntityFrameworkCore;

/// "Диференційна діагностика стану нездужання людини-SEAM" 
/// Розробник Стариченко Олександр Павлович тел.+380674012840, mail staric377@gmail.com
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppRestSeam.Controllers
{
    [Route("api/RegistrationAppointmentController")]
    [ApiController]
    public class RegistrationAppointmentController : ControllerBase
    {
        DbContextSeam db;
        public RegistrationAppointmentController(DbContextSeam context)
        {
            db = context;
            if (!db.Complaints.Any())
            {
                StartLoadDb LoadDb = new();
                LoadDb.AddDb(db);
            }
        }
        // GET: api/<RegistrationAppointmentController>
        [HttpGet]
        public async Task<ActionResult<RegistrationAppointment>> Get()
        {
            List<RegistrationAppointment> _content = await db.RegistrationAppointments.ToListAsync();
            return Ok(_content);
        }

        // GET api/<RegistrationAppointmentController>/5
        [HttpGet("{KodPacient}")]
        public async Task<ActionResult<RegistrationAppointment>> Get(string KodPacient)
        {

            if (KodPacient.Trim().Length == 0) { return NotFound(); }
            List<RegistrationAppointment>  _content = await db.RegistrationAppointments.Where(x => x.KodPacient == KodPacient).ToListAsync(); // 
            return Ok(_content);
        }

        // POST api/<RegistrationAppointmentController>
        [HttpPost]
        public async Task<ActionResult<RegistrationAppointment>> Post(RegistrationAppointment _content)
        {
            if (_content == null) { return BadRequest(); }
            // Создание новой карты жалобы
            try
            {
                db.RegistrationAppointments.Add(_content);
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (db.RegistrationAppointments.Any(x => x.Id != _content.Id)) { return NotFound(); }
            }
            return Ok(_content);
        }

        // PUT api/<RegistrationAppointmentController>/5
        [HttpPut]
        public async Task<ActionResult<RegistrationAppointment>> Put(RegistrationAppointment _content)
        {

            if (_content == null) { return BadRequest(); }
            try
            {
                db.RegistrationAppointments.Update(_content);
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (db.RegistrationAppointments.Any(x => x.Id != _content.Id)) { return NotFound(); }
            }
            return Ok(_content);

        }

        // DELETE api/<RegistrationAppointmentController>/5
        [HttpDelete("{id}/{KodPacienta}/{KodDoctora}")]
        public async Task<ActionResult<RegistrationAppointment>> Delete(string id, string KodPacienta, string KodDoctora)
        {
            if (KodPacienta.Trim() == "0" && id == "0" && KodDoctora.Trim() == "0") { return NotFound(); }
            RegistrationAppointment _content = new RegistrationAppointment();
                
                await db.RegistrationAppointments.FindAsync(Convert.ToInt32(id));
            if (_content == null) { return NotFound(); }
            try
            {

                if (id != "0")
                {

                    if (Convert.ToInt32(id) == -1)
                    {
                        var _compl = await db.RegistrationAppointments.ToListAsync();
                        if (_compl != null)
                        {
                            foreach (RegistrationAppointment str in _compl)
                            {
                                try 
                                {
                                     _content = await db.RegistrationAppointments.FindAsync(Convert.ToInt32(str.Id));
                                    if (_content != null)
                                    {
                                        db.RegistrationAppointments.Remove(_content);
                                        await db.SaveChangesAsync();
                                    }
                                }
                                catch (DbUpdateConcurrencyException)
                                {
                                    if (db.RegistrationAppointments.Any(x => x.Id == _content.Id)) { return BadRequest(); }

                                }
                            }
                        }
                        _content.Id = 0;
                    }
                    else
                    {
                        _content = await db.RegistrationAppointments.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
                        if (_content == null) { return NotFound(); }
                        try
                        {
                            db.RegistrationAppointments.Remove(_content);
                            _content.Id = 0;
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (db.RegistrationAppointments.Any(x => x.Id == _content.Id)) { return BadRequest(); }

                        }
                    }

                }
                if (KodPacienta.Trim() != "0")
                {
                    _content = await db.RegistrationAppointments.FirstOrDefaultAsync(x => x.KodPacient == KodPacienta);
                    if (_content != null) db.RegistrationAppointments.RemoveRange(db.RegistrationAppointments.Where(x => x.KodPacient == KodPacienta));
                }
                if (KodDoctora.Trim() != "0")
                {
                    _content = await db.RegistrationAppointments.FirstOrDefaultAsync(x => x.KodDoctor == KodDoctora);
                    if (_content != null) db.RegistrationAppointments.RemoveRange(db.RegistrationAppointments.Where(x => x.KodDoctor == KodDoctora));
                }
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Convert.ToInt32(id) != 0)
                {
                    if (db.RegistrationAppointments.Any(x => x.Id == _content.Id)) { return BadRequest(); }
                }
                if (KodPacienta.Trim() != "0")
                {
                    if (db.RegistrationAppointments.Any(x => x.KodPacient == _content.KodPacient)) { return BadRequest(); }

                }
                if (KodDoctora.Trim() != "0")
                {
                    if (db.RegistrationAppointments.Any(x => x.KodDoctor == _content.KodDoctor)) { return BadRequest(); }
                }

            }
            return Ok(_content);
        }
    }
}
