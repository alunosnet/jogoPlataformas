using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jogoPlataformas
{
    class Player
    {
        public Game game;
        Texture2D imagem;
        int vida;
        bool esquerda;
        Rectangle retangulo;
        Rectangle posicao;

        public Player(Game game)
        {
            this.game = game;

        }
        public void Initialize()
        {
            posicao.X = 100;
            posicao.Y = 100;
        }
        public void LoadContent()
        {
            imagem = game.Content.Load<Texture2D>("carro");
            retangulo = new Rectangle(0, 0, imagem.Width, imagem.Height);
            posicao.Width = retangulo.Width;
            posicao.Height = retangulo.Height;

        }
        public void Update(KeyboardState teclado)
        {
            if (teclado[Keys.Up] == KeyState.Down) posicao.Y--;
            if (teclado[Keys.Down] == KeyState.Down) posicao.Y++;
            if (teclado[Keys.Left] == KeyState.Down)
            {
                posicao.X--;
                esquerda = true;
            }
            if (teclado[Keys.Right] == KeyState.Down)
            {
                posicao.X++;
                esquerda = false;
            }
            
        }
        public void Draw(SpriteBatch sprites)
        {
            if (!esquerda)
                sprites.Draw(imagem, posicao, Color.White);
            else
                sprites.Draw(imagem,new Vector2(posicao.X,posicao.Y), retangulo, Color.White,
                    0, Vector2.Zero, Vector2.One, SpriteEffects.FlipHorizontally, 0);
        }
    }
}
