using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AlterarUltimoPagamento(int? id)
        {
            var aluno = _context.Alunos.Where(a => a.Id == id).FirstOrDefault();
            if(aluno != null)
            {
                aluno.DataUltimoPagamento = DateTime.Now;
                _context.Alunos.Update(aluno);
                _context.SaveChanges();
            }
        }

        public int CalcularStatus(DateTime data)
        {
            var dataCalculada = DateTime.Now - data;

            return dataCalculada.Days;
        }
        public async Task<Aluno> CreateAluno(Aluno aluno)
        {
            if(aluno.Nome != null)
            {
                _context.Alunos.Add(aluno);
                await _context.SaveChangesAsync();
                return aluno;
            }
            return aluno;
        }

        public async Task<Aluno> DeleteAluno(int id)
        {
            var alunoDeletado = _context.Alunos.Where(a => a.Id == id).FirstOrDefault();
            if(alunoDeletado != null)
            {
                _context.Alunos.Remove(alunoDeletado);
                await _context.SaveChangesAsync();
                return alunoDeletado;
            }
            return alunoDeletado;
        }

        public async Task<List<Aluno>> GetAllAlunos()
        {
            return await _context.Alunos.OrderBy(aluno => aluno.Nome).ToListAsync();
        }

        public async Task<Aluno> GetAluno(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task<Aluno> UpdateAluno(Aluno aluno)
        {
            if(aluno.Id != null)
            {
                _context.Alunos.Update(aluno);
                await _context.SaveChangesAsync();
            }
            return aluno;
        }


    }
}
