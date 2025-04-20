// glslCanvas
var canvas = document.getElementById("glslCanvas");
var sandbox = new GlslCanvas(canvas);

var quality = 1;
canvas.width = window.innerHeight / quality;
canvas.height = window.innerHeight / quality;
canvas.style.transform = 'translate(-50%,-50%) scale('+quality+')';