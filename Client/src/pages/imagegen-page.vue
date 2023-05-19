<template>
    <div class="container d-flex flex-column align-items-center">
        <h3 v-if="!imageGenerated">Please describe the image</h3>
        <div class="mb-3">
            <DxTextArea v-model="imageDescription" placeholder="Enter image description"></DxTextArea>
        </div>
        <div class="mb-3">
            <DxButton @click="generateImage" :disabled="imageGenerating">Generate Image</DxButton>
        </div>
        <div v-if="imageGenerated" class="mb-3">
            <img :src="generatedImageUrl" alt="Generated Image" width="900" height="900">
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { DxTextArea, DxButton } from 'devextreme-vue';

    export default defineComponent({
        components: {
            DxTextArea,
            DxButton,
        },
        data() {
            return {
                imageDescription: '',
                imageGenerating: false,
                imageGenerated: false,
                generatedImageUrl: '',
           };
        },
        methods: {
            async generateImage() {
              if (this.imageDescription) {
                this.imageGenerating = true;
                try {
                  const response = await fetch('http://localhost:5000/api/ImageGenerationAPI', {
                    method: 'POST',
                    headers: {
                      'Content-Type': 'application/json',
                    },
                    body: `\"${this.imageDescription}\"`,
                  });
                  const imageUrl = await response.json();
                  this.generatedImageUrl = imageUrl;
                  this.imageGenerated = true;
                } catch (error) {
                  console.error(error);
                } finally {
                  this.imageGenerating = false;
                }
              }
            },
          },
    });
</script>

<style scoped>
    .container {
        margin-top: 20vh;
        text-align: center;
    }
</style>
