function applyGradient(elems, grad) {
	for (let i = 0; i < elems.length; i++) {
		GradientMaps.applyGradientMap(elems[i], grad);
	}
}
const style = getComputedStyle(document.documentElement);
const colors = [ 
	style.getPropertyValue("--color-back").trim(),
	style.getPropertyValue("--color-vibe").trim()
];
const grad = colors.join(',');