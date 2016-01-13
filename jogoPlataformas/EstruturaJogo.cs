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
        int opMenu; //posição selecionada no menu
        Texture2D opJogar;
        Texture2D opSair;
        bool disparou = false;

        public EstruturaJogo(Game game)
        {
            this.game = game;
        }
        public void Initialize()
        {
            estado = 0;

            opMenu = 1;
        }
        public void LoadContent()
        {
            opJogar = game.Content.Load<Texture2D>("jogar");
            opSair = game.Content.Load<Texture2D>("sair");
        }
        public void Update(GameTime gameTime)
        {
            //atualizar jogo
            if (estado == 0) atualizarMenu();
            //atualizar menu

        }
        public void atualizarMenu()
        {
            
            //teclas
            teclado = Keyboard.GetState();

            gamepad = GamePad.GetState(PlayerIndex.One);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                game.Exit();

            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                return;


            if (teclado[Keys.Down] == KeyState.Down || teclado[Keys.Up] == KeyState.Down || teclado[Keys.Enter] == KeyState.Down)
            {
                if (disparou == true) return;
                disparou = true;
            }
            else
                disparou = false;

            if (teclado[Keys.Up] == KeyState.Down)
            {
                disparou = true;
                opMenu--;
            }
            if (teclado[Keys.Down] == KeyState.Down)
            {
                opMenu++;
                disparou = true;
            }
            if (opMenu < 1) opMenu = 2;
            if (opMenu > 2) opMenu = 1;

            if (teclado[Keys.Enter] == KeyState.Down)
            {
                if (opMenu == 1) estado = 1;
                if (opMenu == 2) game.Exit();
            }

            return;

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

            
            if (opMenu==1)
                cor = Color.White;
            else
                cor = Color.Brown;
            rtemp = new Rectangle(0, 0, opJogar.Width, opJogar.Height);
            spriteBatch.Draw(opJogar, rtemp, cor);

            if (opMenu==2)
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
