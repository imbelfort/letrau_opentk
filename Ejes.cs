using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace LetraU
{

    class Ejes
    {
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
    }

}
