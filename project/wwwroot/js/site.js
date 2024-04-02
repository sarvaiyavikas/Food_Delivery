// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



let navbar = document.querySelector('.header .flex .navbar');
let profile = document.querySelector('.header .flex .profile');

document.querySelector('#menu-btn').onclick = () => {
    navbar.classList.toggle('active');
    profile.classList.remove('active');
}

document.querySelector('#user-btn').onclick = () => {
    profile.classList.toggle('active');
    navbar.classList.remove('active');
}

window.onscroll = () => {
    profile.classList.remove('active');
    navbar.classList.remove('active');
}

function loader() {
    document.querySelector('.loader').style.display = 'none';
}

function fadeOut() {
    setInterval(loader, 2000);
}

window.onload = fadeOut;