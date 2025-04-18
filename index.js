// glslCanvas resolution
var canvas = document.getElementById("glslCanvas");
var sandbox = new GlslCanvas(canvas);

var quality = 1;
canvas.width = window.innerHeight / quality;
canvas.height = window.innerHeight / quality;
canvas.style.transform = 'translate(-50%,-50%) scale('+quality+')';

// gradients
function applyGradient(elems, grad) {
	for (let i = 0; i < elems.length; i++) {
		GradientMaps.applyGradientMap(elems[i], grad);
	}
}

var gradient = "#1a1423, #00f0b5";
applyGradient(document.getElementsByClassName("work__image__top"), gradient);
applyGradient(document.getElementsByClassName("about__photo"), gradient);