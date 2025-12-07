namespace UnityEngine.Rendering
{
    public static partial class CoreUtils
    {
                
        // Caution: such a call should not be use interleaved with command buffer command, as it is immediate
        /// <summary>
        /// Set a keyword immediately on a compute shader
        /// </summary>
        /// <param name="cmd">CommandBuffer on which to set the global keyword.</param>
        /// <param name="cs">Compute Shader on which to set the keyword.</param>
        /// <param name="keyword">Keyword to be set.</param>
        /// <param name="state">Value of the keyword to be set.</param>
        public static void SetKeyword(ComputeCommandBuffer cmd, ComputeShader cs, string keyword, bool state)
        {
            if (state)
                cmd.m_WrappedCommandBuffer.EnableShaderKeyword(keyword);
            else
                cmd.m_WrappedCommandBuffer.DisableShaderKeyword(keyword);
        }

    }
}