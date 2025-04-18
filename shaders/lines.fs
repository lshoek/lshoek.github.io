// Author @lesleyvanhoek (lesleyvanhoek.nl) - 2018
// Title: Stripe Patterns

#ifdef GL_ES
precision lowp float;
#endif

#define inv(x) 1.0 - x

uniform vec2 u_resolution;
uniform float u_time;

const vec3 u_color0 = vec3(0.090, 0.192, 0.211); 
const vec3 u_color1 = vec3(0.101, 0.078, 0.137);

const float thickness = 0.065;
const float tiles = 4.0;
const float offset = 0.2/tiles;
const float margin = 0.075;

vec2 tile(vec2 st, float zoom)
{
    st *= zoom;
    return vec2(st.x, fract(st.y));
}

vec2 rotate(vec2 coord, float angle) 
{
    return mat2(cos(angle),-sin(angle), sin(angle),cos(angle)) * coord;
}

float rect(vec2 st, vec2 dim)
{
    dim = 0.25-dim*0.25;
    vec2 uv = step(dim, st*(inv(st)));
    return uv.y;
}

float stripe(float p, float w0, float w1, float offset) 
{
    float w = w0 + w1;
    return step(w0, mod(p + offset, w));
}

void main()
{
    vec2 st = gl_FragCoord.xy/u_resolution;    
    
    // tile the scene
    vec2 grid = tile(st, tiles);

    // cut out horizontal margins
    float x = step(margin, grid.y) * step(margin, inv(grid.y));
    
    // cut out shape
    float row = floor(st.y*tiles)/tiles;
    float vary = 2.165*row;
    float warp = rotate(grid + sin((u_time+row*4.0)/8.0)*(row+0.25), cos(dot(st.xy, vec2(row) + 2.0*vec2(0.590,0.730)))).x;
    x -= stripe(warp, 0.015+vary*thickness, thickness, u_time/32.0);
    
    // mix
    gl_FragColor = vec4(mix(u_color1, u_color0, max(x, 0.0)), 1.0);
}
