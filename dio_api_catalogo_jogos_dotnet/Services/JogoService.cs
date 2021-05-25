﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_api_catalogo_jogos_dotnet.Entities;
using dio_api_catalogo_jogos_dotnet.Exceptions;
using dio_api_catalogo_jogos_dotnet.InputModel;
using dio_api_catalogo_jogos_dotnet.Repositories;
using dio_api_catalogo_jogos_dotnet.ViewModel;

namespace dio_api_catalogo_jogos_dotnet.Services
{
    public class JogoService : IJogoService
    {
        public readonly IJogoRepository _JogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _JogoRepository = jogoRepository;
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            var jogos = await _JogoRepository.Obter(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            }).ToList();
        }

        public async Task<JogoViewModel> Obter(Guid id)
        {
            var jogo = await _JogoRepository.Obter(id);

            if (jogo == null)
            {
                return null;
            }

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            var entidadeJogo = await _JogoRepository.Obter(jogo.Nome, jogo.Produtora);

            if (entidadeJogo.Count > 0)
            {
                throw new JogoJaCadastradoException();
            }

            var jogoInsert = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };

            await _JogoRepository.Inserir(jogoInsert);

            return new JogoViewModel
            {
                Id = jogoInsert.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task Atualizar(Guid id, JogoInputModel jogo)
        {
            var entidadeJogo = await _JogoRepository.Obter(id);

            if (entidadeJogo == null)
            {
                throw new JogoNaoCadastradoException();
            }

            entidadeJogo.Nome = jogo.Nome;
            entidadeJogo.Produtora = jogo.Produtora;
            entidadeJogo.Preco = jogo.Preco;

            await _JogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeJogo = await _JogoRepository.Obter(id);

            if (entidadeJogo == null)
            {
                throw new JogoNaoCadastradoException();
            }

            
            entidadeJogo.Preco = preco;

            await _JogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Remover(Guid id)
        {
            var jogo = await _JogoRepository.Obter(id);

            if (jogo == null)
            {
                throw new JogoNaoCadastradoException();
            }

            await _JogoRepository.Remover(id);
        }

        public void Dispose()
        {
            _JogoRepository?.Dispose();
        }
    }
}