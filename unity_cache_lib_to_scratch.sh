#!/bin/bash

u="$USER"
scratch_home="/scratch/$u"
unity_cache="$scratch_home/.unity"

lib_app_supp="$HOME/Library/Application Support"
lib_caches_unity="$HOME/Library/Caches/com.unity3d.UnityEditor"

if [ ! -d "$scratch_home" ]; then
    mkdir -p "$scratch_home"
    chmod 700 "$scratch_home"
fi

if [ ! -d "$unity_cache" ]; then
    mkdir -p "$unity_cache"
    chmod 700 "$unity_cache"
fi

if [ -L "$lib_app_supp/DefaultCompany" ]; then
    if [ ! -d "$unity_cache/DefaultCompany" ]; then
        mkdir "$unity_cache/DefaultCompany"
    fi
else
    if [ ! -d "$lib_app_supp/DefaultCompany" ]; then 
        mkdir "$lib_app_supp/DefaultCompany"
    fi
    mv -f "$lib_app_supp/DefaultCompany" "$unity_cache/"
    ln -s "$unity_cache/DefaultCompany" "$lib_app_supp/DefaultCompany"
    echo "Sym linked $lib_app_supp/DefaultCompany to $unity_cache/DefaultCompany."
fi

if [ -L "$lib_app_supp/Unity" ]; then
    if [ ! -d "$unity_cache/Unity" ]; then
        mkdir "$unity_cache/Unity"
    fi
else
    if [ ! -d "$lib_app_supp/Unity" ]; then
        mkdir "$lib_app_supp/Unity"
    fi
    mv -f "$lib_app_supp/Unity" "$unity_cache/"
    ln -s "$unity_cache/Unity" "$lib_app_supp/Unity"
    echo "Sym linked $lib_app_supp/Unity to $unity_cache/Unity."
fi


if [ -L "$lib_caches_unity" ]; then
    if [ ! -d "$unity_cache/com.unity3d.UnityEditor" ]; then
        mkdir "$unity_cache/com.unity3d.UnityEditor"
    fi
else
    if [ ! -d "$lib_caches_unity" ]; then
        mkdir "$lib_caches_unity"
    fi
    mv -f "$lib_caches_unity" "$unity_cache/"
    ln -s "$unity_cache/com.unity3d.UnityEditor" "$lib_caches_unity"
    echo "Sym linked $lib_caches_unity to $unity_cache/com.unity3d.UnityEditor."
fi
