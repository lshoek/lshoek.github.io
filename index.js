/* -----------------------------------------
  Have focus outline only for keyboard users 
 ---------------------------------------- */

const handleFirstTab = (e) => {
  if(e.key === 'Tab') {
    document.body.classList.add('user-is-tabbing')

    window.removeEventListener('keydown', handleFirstTab)
    window.addEventListener('mousedown', handleMouseDownOnce)
  }

}

const handleMouseDownOnce = () => {
  document.body.classList.remove('user-is-tabbing')

  window.removeEventListener('mousedown', handleMouseDownOnce)
  window.addEventListener('keydown', handleFirstTab)
}

window.addEventListener('keydown', handleFirstTab)

const backToTopButton = document.querySelector(".back-to-top");
let isBackToTopRendered = false;

let alterStyles = (isBackToTopRendered) => {
  backToTopButton.style.visibility = isBackToTopRendered ? "visible" : "hidden";
  backToTopButton.style.opacity = isBackToTopRendered ? 1 : 0;
  backToTopButton.style.transform = isBackToTopRendered
    ? "scale(1)"
    : "scale(0)";
};

window.addEventListener("scroll", () => {
  if (window.scrollY > 700) {
    isBackToTopRendered = true;
    alterStyles(isBackToTopRendered);
  } else {
    isBackToTopRendered = false;
    alterStyles(isBackToTopRendered);
  }
});


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