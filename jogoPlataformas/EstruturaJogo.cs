using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jogoPlataformas
{
    //Classe que implementa:
    // - Menu do jogo
    // - ciclo do Jogo
    class EstruturaJogo
    {
        KeyboardState teclado;
        GamePadState gamepad;
        Game game;
        int estado; //0-Menu; 1-Jogo; 2-Pausa
        Texture2D opJogar;
        Texture2D opSair;

        public EstruturaJogo(Game game)
        {
            this.game = game;
        }
        public void Initialize()
        {
            estado = 0;
        }
        public void LoadContent()
        {
            opJogar = game.Content.Load<Texture2D>("jogar");
            opSair = game.Content.Load<Texture2D>("sair");
        }
        public void Update(GameTime gameTime)
        {
            //atualizar jogo
            
            //atualizar menu

        }
        public void Draw(GameTime gameTime,GraphicsDevice dispositivo, SpriteBatch spriteBatch)
        {
            dispositivo.Clear(Color.CornflowerBlue);
            //iniciar desenhar
            spriteBatch.Begin();
            
            //desenhar menu
            if (estado == 0)
                desenhaMenu(gameTime, spriteBatch);
            //desenhar jogo
            if (estado == 1)
                desenhaJogo(gameTime, spriteBatch);
            
            //terminar desenhar
            spriteBatch.End();
        }
        public void desenhaMenu(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Rectangle rtemp;
            Color cor;

            
            if (estado==0)
                cor = Color.White;
            else
                cor = Color.Brown;
            rtemp = new Rectangle(0, 0, opJogar.Width, opJogar.Height);
            spriteBatch.Draw(opJogar, rtemp, cor);
            if (estado==1)
                cor = Color.White;
            else
                cor = Color.Brown;

            rtemp = new Rectangle(0, 200, opSair.Width, opSair.Height);
            spriteBatch.Draw(opSair, rtemp, cor);

            
        }
        public void desenhaJogo(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
        }
}
