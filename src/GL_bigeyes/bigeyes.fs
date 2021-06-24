#version 330 core
out vec4 FragColor;

in vec2 TexCoord;

uniform vec2 u_left_center;// 左眼中心点
uniform vec2 u_right_center;// 右眼中心点
uniform vec2 u_img_size;//图片分辨率

uniform float u_scaleRatio;//放大系数
uniform float u_radius;// 影响半径
//
// // texture sampler
uniform sampler2D texture1;
//


vec2 warpEyes(vec2 centerPos, vec2 curPos, float radius, float scaleRatio)
{
     vec2 result = curPos;
     vec2 imgCurPos = curPos*u_img_size;
     float d = distance(imgCurPos,centerPos);

     if(d < radius){
         float gamma = 1.0 - scaleRatio * pow(smoothstep(0.0, 1.0, d / radius) - 1.0, 2.0);
         vec2 result = centerPos + gamma * (imgCurPos - centerPos);
         result = result / u_img_size;

         return result;
     }

    return result;
}




void main()
{

    vec2 newTexCoord = warpEyes(u_left_center, TexCoord, u_radius,u_scaleRatio);
    newTexCoord = warpEyes(u_right_center, newTexCoord, u_radius, u_scaleRatio);
    FragColor = texture(texture1, newTexCoord);

}
//



