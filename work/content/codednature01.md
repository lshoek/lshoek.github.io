___content___
### Coded Nature I: Swarm
#### Studio DRIFT, 2023

"Coded Nature explores the relationship between humans, nature and technology. An autonomously flying swarm of DRIFT blocks responds to the movement of the audience, reflecting the endless opportunities of creation in nature as well as a continuous flow of change. The work was unveiled and shown to public for the first time, at Art Basel Miami 2022." - Studio DRIFT

My contribution to this work was the design and implementation of a custom starling swarming algorithm. It takes full advantage of GPU acceleration through shared memory and spatial partitioning optimizations -- all C++/Vulkan/GLSL. The result is a mesmerizing simulation of well over 50.000 birds.

Additionally, my contributions dealt with the rendering pipeline; implementing post-processing effects; programming the lighting model etc.

Coen Klösters built an exceptionally efficient atmospheric scattering model.

Tim Groeneboom built a highly accurate user-interaction system using object tracking, for which he built a NAP Intel RealSense module.

(I wrote an [article](https://blog.nap-labs.tech/df/d25/md_articles_007_nap_vulkan_compute.html) about the compute pipeline I built for NAP framework)

Artwork: [Studio DRIFT](https://studiodrift.com)  
Software: [NAP Labs](https://nap-labs.tech)  
___end___

___image___
![Coded Nature I at PACE gallery, 2022](../images/codednature01_01.webp)
![Coded Nature I at PACE gallery, 2022](../images/codednature01_02.jpg)
___end___

___embed___
[Coded Nature I - DRIFT at LUMA, Arles, 2024](https://www.youtube.com/embed/gibdzV6ZxYE){640,360}
___end___
