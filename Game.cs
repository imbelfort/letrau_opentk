using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace LetraU
{
    class Game : GameWindow
    {
        public Game(int width, int height) : base(width, height, GraphicsMode.Default, "Diseño Letra U - 3D")
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.0f, 0.5f, 0.0f, 1.0f);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            float aspectRatio = (float)Width / Height;
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45.0f), aspectRatio, 0.1f, 100.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }


                // Método para dibujar los ejes X, Y, Z con colores diferentes
        public void DibujarEjes(float longitud)
        {
            // Grosor de línea para los ejes
            GL.LineWidth(2.0f);

            // Eje X en rojo
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(1.0f, 0.0f, 0.0f); // Rojo
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(longitud, 0.0f, 0.0f);
            GL.End();

            // Eje Y en verde
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(0.0f, 1.0f, 0.0f); // Verde
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, longitud, 0.0f);
            GL.End();

            // Eje Z en azul
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(0.0f, 0.0f, 1.0f); // Azul
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, longitud);
            GL.End();

            // Volver al grosor de línea por defecto
            GL.LineWidth(1.0f);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            Matrix4 modelview = Matrix4.LookAt(
                new Vector3(1.5f, 2f, 3.5f), // Posición de la cámara
                new Vector3(0.0f, 0.1f, 0.0f), // Punto de mira
                Vector3.UnitY); 
            GL.LoadMatrix(ref modelview);

            GL.PushMatrix();

            DibujarEjes(1.5f); 

            float posX = 0.9f; 
            float posY = 0.0f;  
            float posZ = 0.0f; 
   
    GL.Begin(PrimitiveType.LineLoop);
    // Parte frontal
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX - 0.4f, posY + 0.6f, posZ + 0.15f);
    GL.Vertex3(posX - 0.2f, posY + 0.6f, posZ + 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ + 0.15f);
    GL.Vertex3(posX - 0.4f, posY - 0.4f, posZ + 0.15f);            
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);            
    // Parte superior
    GL.Vertex3(posX - 0.4f, posY + 0.6f, posZ + 0.15f);
    GL.Vertex3(posX - 0.4f, posY + 0.6f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY + 0.6f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY + 0.6f, posZ + 0.15f);
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte inferior
    GL.Vertex3(posX - 0.4f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ + 0.15f);
    GL.Vertex3(posX - 0.4f, posY - 0.4f, posZ + 0.15f);            
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte trasera
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX - 0.4f, posY + 0.6f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY + 0.6f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX - 0.4f, posY - 0.4f, posZ - 0.15f);
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte lateral izquierda
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX - 0.4f, posY + 0.6f, posZ + 0.15f);
    GL.Vertex3(posX - 0.4f, posY + 0.6f, posZ - 0.15f);
    GL.Vertex3(posX - 0.4f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX - 0.4f, posY - 0.4f, posZ + 0.15f);                
    GL.End();
    
    GL.Begin(PrimitiveType.LineLoop);
    // Parte lateral derecha
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX - 0.2f, posY + 0.6f, posZ + 0.15f);
    GL.Vertex3(posX - 0.2f, posY + 0.6f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ + 0.15f);                
    GL.End();

    // --------- SEGUNDO RECTÁNGULO (PARTE BASE HORIZONTAL DE LA U) ---------
    GL.Begin(PrimitiveType.LineLoop);
    // Parte frontal
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX - 0.2f, posY - 0.2f, posZ + 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.2f, posZ + 0.15f);  
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ + 0.15f); 
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ + 0.15f); 
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte superior 
    GL.Vertex3(posX - 0.2f, posY - 0.2f, posZ + 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.2f, posZ + 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.2f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.2f, posZ - 0.15f);
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte inferior
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ + 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ + 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte trasera
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX - 0.2f, posY - 0.2f, posZ - 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.2f, posZ - 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte lateral izquierda 
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX - 0.2f, posY - 0.2f, posZ + 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.2f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX - 0.2f, posY - 0.4f, posZ + 0.15f);
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte lateral derecha 
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX + 0.2f, posY - 0.2f, posZ + 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.2f, posZ - 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ + 0.15f);
    GL.End();

    // --------- TERCER RECTÁNGULO (LADO DERECHO VERTICAL DE LA U) ---------
    GL.Begin(PrimitiveType.LineLoop);
    // Parte frontal
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX + 0.2f, posY + 0.6f, posZ + 0.15f);
    GL.Vertex3(posX + 0.4f, posY + 0.6f, posZ + 0.15f);
    GL.Vertex3(posX + 0.4f, posY - 0.4f, posZ + 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ + 0.15f);
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte superior
    GL.Vertex3(posX + 0.2f, posY + 0.6f, posZ + 0.15f);
    GL.Vertex3(posX + 0.4f, posY + 0.6f, posZ + 0.15f);
    GL.Vertex3(posX + 0.4f, posY + 0.6f, posZ - 0.15f);
    GL.Vertex3(posX + 0.2f, posY + 0.6f, posZ - 0.15f);
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte inferior 
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ + 0.15f);
    GL.Vertex3(posX + 0.4f, posY - 0.4f, posZ + 0.15f);
    GL.Vertex3(posX + 0.4f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte trasera
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX + 0.2f, posY + 0.6f, posZ - 0.15f);
    GL.Vertex3(posX + 0.4f, posY + 0.6f, posZ - 0.15f);
    GL.Vertex3(posX + 0.4f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte lateral izquierda
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX + 0.2f, posY + 0.6f, posZ + 0.15f);
    GL.Vertex3(posX + 0.2f, posY + 0.6f, posZ - 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX + 0.2f, posY - 0.4f, posZ + 0.15f);
    GL.End();

    GL.Begin(PrimitiveType.LineLoop);
    // Parte lateral derecha
    GL.Color4(0.0f, 0.0f, 0.0f, 0.0f);
    GL.Vertex3(posX + 0.4f, posY + 0.6f, posZ + 0.15f);
    GL.Vertex3(posX + 0.4f, posY + 0.6f, posZ - 0.15f);
    GL.Vertex3(posX + 0.4f, posY - 0.4f, posZ - 0.15f);
    GL.Vertex3(posX + 0.4f, posY - 0.4f, posZ + 0.15f);
    GL.End();
          

            GL.PopMatrix();

            SwapBuffers();
        }


    }
}
