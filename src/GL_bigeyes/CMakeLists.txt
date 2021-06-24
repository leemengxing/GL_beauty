cmake_minimum_required(VERSION 3.5)

find_package(glfw3 REQUIRED)
find_package(OpenCV REQUIRED)

include_directories(
        ${OpenCV_INCLUDE_DIRS}
)
include_directories(../../include)

aux_source_directory(. SRC_LIST)

add_executable(GL_bigeyes ${SRC_LIST})

target_link_libraries(GL_bigeyes -lglfw -lGL -lm -lXrandr -lXi -lX11 -lXxf86vm -lpthread
        -ldl
        -lXinerama
        -lXcursor
        ${OpenCV_LIBS}
        )