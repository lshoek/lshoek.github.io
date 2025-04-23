// Author @lesleyvanhoek (lesleyvanhoek.nl) - 2018
// Title: Stripe Patterns

#ifdef GL_ES
precision lowp float;
#endif

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

const vec3 color0 = vec3(0.090, 0.192, 0.211); 
const vec3 color1 = vec3(0.101, 0.078, 0.137);

const float thickness = 0.076;
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
    vec2 uv = step(dim, st*(1.0-st));
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
    float x = step(margin, grid.y) * step(margin, 1.0-grid.y);
    
    // cut out shape
    float row = floor(st.y*tiles);
    float r = row/tiles;
    float warp = rotate(grid + sin((u_time+r*4.0)/8.0)*(r+0.242), cos(dot(st.xy, vec2(r) + 1.896*vec2(0.780,0.750)))).x * 1.912;
    
    // cut out stripes
    float row_mouse = (u_mouse.y/u_resolution.y)*tiles;
	float m = -r*0.096 + 0.070 * min(distance(row+0.5, row_mouse), 0.5);
    float thick = 0.844 * thickness * (row+1.0);
    x -= stripe(warp, thick-m, thick+m, u_time/32.0);

    // mix
    gl_FragColor = vec4(mix(color1, color0, max(x, 0.0)), 1.0);
}